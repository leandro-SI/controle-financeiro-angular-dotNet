import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Categoria } from 'src/app/models/Categoria';
import { Ganho } from 'src/app/models/Ganho';
import { Mes } from 'src/app/models/Mes';
import { CategoriasService } from 'src/app/services/categorias/categorias.service';
import { GanhosService } from 'src/app/services/ganhos/ganhos.service';
import { MesesService } from 'src/app/services/meses/mes.service';

@Component({
  selector: 'app-novo-ganho',
  templateUrl: './novo-ganho.component.html',
  styleUrls: ['./novo-ganho.component.css']
})
export class NovoGanhoComponent implements OnInit {

  formulario: any;
  ganhos: Ganho[];
  categorias: Categoria[];
  meses: Mes[];
  erros: string[];
  usuarioId: string = localStorage.getItem('UsuarioId')

  constructor(private ganhoService: GanhosService,
    private mesService: MesesService,
    private categoriaService: CategoriasService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.erros = [];

    this.categoriaService.filtrarCategoriasGanhos().subscribe(result => {
      this.categorias = result;
    })

    this.mesService.getAll().subscribe(result => {
      this.meses = result;
    })

    this.formulario = new FormGroup({
      descricao: new FormControl(null, [Validators.required, Validators.minLength(1), Validators.maxLength(50)]),
      categoriaId: new FormControl(null, [Validators.required]),
      valor: new FormControl(null, [Validators.required]),
      dia: new FormControl(null, [Validators.required]),
      mesId: new FormControl(null, [Validators.required]),
      ano: new FormControl(null, [Validators.required]),
      usuarioId: new FormControl(this.usuarioId)
    })
  }

  get propriedade() {
    return this.formulario.controls;
  }

  EnviarFormulario(): void {
    const despesa = this.formulario.value
    this.erros = [];
    this.ganhoService.create(despesa).subscribe(result => {
      this.snackBar.open(result.mensagem, null, {
        duration: 3000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
      })
      this.router.navigate(['ganhos/listar']);
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
    this.router.navigate(['ganhos/listar'])
  }

}
