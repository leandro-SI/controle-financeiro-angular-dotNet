import { Component, OnInit } from '@angular/core';
import { Tipo } from 'src/app/models/Tipo';
import { TiposService } from 'src/app/services/tipos/tipos.service';
import { FormGroup, FormControl } from '@angular/forms';
import { CategoriasService } from './../../../services/categorias/categorias.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-nova-categoria',
  templateUrl: './nova-categoria.component.html',
  styleUrls: ['./nova-categoria.component.scss']
})
export class NovaCategoriaComponent implements OnInit {

  formulario: any;
  tipos: Tipo[]
  erros: string[];

  constructor(private tipoService: TiposService,
    private categoriaService: CategoriasService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.erros = [];

    this.tipoService.GetAll().subscribe(result => {
      this.tipos = result;
    })

    this.formulario = new FormGroup({
      nome: new FormControl(null),
      icone: new FormControl(null),
      tipoId: new FormControl(null),
    })
  }

  get propriedade() {
    return this.formulario.controls;
  }

  EnviarFormulario() : void {
    const categoria = this.formulario.value
    this.erros = [];
    this.categoriaService.create(categoria).subscribe(result => {
      this.snackBar.open(result.mensagem, null, {
        duration: 2000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
      })
      this.router.navigate(['categorias/listar']);
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

  VoltarListagem(): void {
    this.router.navigate(['categorias/listar'])
  }

}
