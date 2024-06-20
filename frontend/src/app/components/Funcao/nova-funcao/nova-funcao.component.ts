import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { FuncoesService } from 'src/app/services/funcoes/funcoes.service';

@Component({
  selector: 'app-nova-funcao',
  templateUrl: './nova-funcao.component.html',
  styleUrls: ['./nova-funcao.component.scss']
})
export class NovaFuncaoComponent implements OnInit {

  formulario: any;
  erros: string[];

  constructor(private funcaoService: FuncoesService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.erros = [];

    this.formulario = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.maxLength(50)]),
      descricao: new FormControl(null, [Validators.required, Validators.maxLength(50)])
    })
  }

  get propriedade() {
    return this.formulario.controls;
  }

  EnviarFormulario() : void {
    const funcao = this.formulario.value
    this.erros = [];
    this.funcaoService.create(funcao).subscribe(result => {
      this.snackBar.open(result.mensagem, null, {
        duration: 3000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
      })
      this.router.navigate(['funcoes/listar']);
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
    this.router.navigate(['funcoes/listar'])
  }

}
