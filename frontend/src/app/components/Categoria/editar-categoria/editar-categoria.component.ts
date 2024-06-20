import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria } from 'src/app/models/Categoria';
import { Tipo } from 'src/app/models/Tipo';
import { ActivatedRoute, Router } from '@angular/router';
import { TiposService } from 'src/app/services/tipos/tipos.service';
import { CategoriasService } from 'src/app/services/categorias/categorias.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-editar-categoria',
  templateUrl: './editar-categoria.component.html',
  styleUrls: ['./editar-categoria.component.scss']
})
export class EditarCategoriaComponent implements OnInit {

  categoria: Observable<Categoria>;
  nomeCategoria: string;
  categoriaId: number
  tipos: Tipo[];
  formulario: any;
  erros: string[];

  constructor(private router: Router,
    private route: ActivatedRoute,
    private tipoService: TiposService,
    private categoriaService: CategoriasService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.erros = [];
    this.categoriaId = this.route.snapshot.params.id;

    this.tipoService.GetAll().subscribe(result => {
      this.tipos = result;
    })

    this.categoriaService.getById(this.categoriaId).subscribe(result => {
      this.nomeCategoria = result.nome;
      this.formulario = new FormGroup({
        id: new FormControl(result.id),
        nome: new FormControl(result.nome, [Validators.required, Validators.maxLength(50)]),
        icone: new FormControl(result.icone, [Validators.required, Validators.maxLength(15)]),
        tipoId: new FormControl(result.tipoId, [Validators.required])
      })
    });
  }

  get propriedade() {
    return this.formulario.controls;
  }

  VoltarListagem(): void {
    this.router.navigate(['categorias/listar'])
  }

  AtualizarCategoria() : void {
    const categoria = this.formulario.value;
    this.erros = [];
    this.categoriaService.update(this.categoriaId, categoria).subscribe(result => {
      this.snackBar.open(result.mensagem, null, {
        duration: 3000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
      })
      this.VoltarListagem();
    },
    (err) => {
      if (err.error.status === 400) {
        for(const campo in err.error.errors) {
          if (err.error.errors.hasOwnProperty(campo)) {
            this.erros.push(err.error.errors[campo])
          }
        }
      }
    })
  }

}
