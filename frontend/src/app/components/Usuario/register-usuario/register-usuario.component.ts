import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UsuariosService } from 'src/app/services/usuarios/Usuarios.service';

@Component({
  selector: 'app-register-usuario',
  templateUrl: './register-usuario.component.html',
  styleUrls: ['./register-usuario.component.css']
})
export class RegisterUsuarioComponent implements OnInit {

  formulario: any;
  foto: File = null;
  erros = [];

  constructor(private usuarioService: UsuariosService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.erros = [];

    this.formulario = new FormGroup({
      nomeUsuario: new FormControl(null, [Validators.required, Validators.minLength(6), Validators.maxLength(50)]),
      cpf: new FormControl(null, [Validators.required, Validators.minLength(1), Validators.maxLength(20)]),
      profissao: new FormControl(null, [Validators.required, Validators.minLength(1), Validators.maxLength(30)]),
      foto: new FormControl(null, [Validators.required]),
      email: new FormControl(null, [Validators.required, Validators.minLength(1), Validators.maxLength(30)]),
      senha: new FormControl(null, [Validators.required, Validators.minLength(1), Validators.maxLength(30)]),
    })
  }

  get propriedade() {
    return this.formulario.controls;
  }

  EnviarFormulario() : void {
    const registroUsuario = this.formulario.value
    this.erros = [];
    this.usuarioService.registrarUsuario(registroUsuario).subscribe(result => {
      this.snackBar.open(result.mensagem, null, {
        duration: 2000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
      })
      this.router.navigate(['Usuarios/listar']);
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
