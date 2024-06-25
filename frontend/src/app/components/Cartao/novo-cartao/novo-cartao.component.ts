import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { CartoesService } from 'src/app/services/cartoes/cartoes.service';

@Component({
  selector: 'app-novo-cartao',
  templateUrl: './novo-cartao.component.html',
  styleUrls: ['./novo-cartao.component.scss']
})
export class NovoCartaoComponent implements OnInit {

  formulario: any;
  erros: string[];
  usuarioId: string = localStorage.getItem('UsuarioId')

  constructor(private cartaoService: CartoesService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.erros = [];

    this.formulario = new FormGroup({
      nome: new FormControl(null, [Validators.required, Validators.min(1), Validators.maxLength(20)]),
      bandeira: new FormControl(null, [Validators.required, Validators.min(1), Validators.maxLength(15)]),
      numero: new FormControl(null, [Validators.required, Validators.min(1), Validators.maxLength(20)]),
      limite: new FormControl(null, [Validators.required]),
      usuarioId: new FormControl(this.usuarioId)
    })
  }

  get propriedade() {
    return this.formulario.controls;
  }

  EnviarFormulario() : void {
    const cartao = this.formulario.value
    this.erros = [];
    this.cartaoService.create(cartao).subscribe(result => {
      this.snackBar.open(result.mensagem, null, {
        duration: 3000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
      })
      this.router.navigate(['cartoes/listar']);
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
    this.router.navigate(['cartoes/listar'])
  }

}
