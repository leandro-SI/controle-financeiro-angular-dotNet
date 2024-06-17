import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria } from 'src/app/models/Categoria';
import { Tipo } from 'src/app/models/Tipo';
import { ActivatedRoute, Router } from '@angular/router';
import { TiposService } from 'src/app/services/tipos/tipos.service';
import { CategoriasService } from 'src/app/services/categorias/categorias.service';
import { FormControl, FormGroup } from '@angular/forms';

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

  constructor(private router: Router,
    private route: ActivatedRoute,
    private tipoService: TiposService,
    private categoriaService: CategoriasService
  ) { }

  ngOnInit() {
    this.categoriaId = this.route.snapshot.params.id;

    this.tipoService.GetAll().subscribe(result => {
      this.tipos = result;
    })

    this.categoriaService.getById(this.categoriaId).subscribe(result => {
      this.nomeCategoria = result.nome;
      this.formulario = new FormGroup({
        id: new FormControl(result.id),
        nome: new FormControl(result.nome),
        icone: new FormControl(result.icone),
        tipoId: new FormControl(result.tipoId)
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

    this.categoriaService.update(this.categoriaId, categoria).subscribe(result => {
      this.VoltarListagem();
    })
  }

}
