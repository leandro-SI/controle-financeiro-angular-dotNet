import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { UsuariosService } from 'src/app/services/usuarios/Usuarios.service';

@Component({
  selector: 'app-login-usuario',
  templateUrl: './login-usuario.component.html',
  styleUrls: ['./login-usuario.component.scss']
})
export class LoginUsuarioComponent implements OnInit {

  formulario: any;
  erros: string[];

  constructor(private usuarioService: UsuariosService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.erros = [];

    this.formulario = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.minLength(10), Validators.maxLength(50), Validators.email]),
      senha: new FormControl(null, [Validators.required, Validators.minLength(1), Validators.maxLength(30)]),
    })

  }

  get propriedade() {
    return this.formulario.controls;
  }

  EnviarFormulario() : void {
    this.erros = [];
    const usuario = this.formulario.value;

    this.usuarioService.logarUsuario(usuario).subscribe(result => {
      const emailUsuarioLogado = result.email;
      const usuarioId = result.usuarioId;
      const tokenUsuario = result.token;

      localStorage.setItem('EmailUsuarioLogado', emailUsuarioLogado);
      localStorage.setItem('UsuarioId', usuarioId);
      localStorage.setItem('TokenUsuario', tokenUsuario);
      this.router.navigate(['/categorias/listar']);

    },
    (err) => {
      if (err.status === 400) {
        for(const campo in err.error.errors) {
          if (err.error.errors.hasOwnProperty(campo)) {
            this.erros.push(err.error.errors[campo])
          }
        }
      } else {
        this.erros.push(err.error);
      }
    })

  }

}
