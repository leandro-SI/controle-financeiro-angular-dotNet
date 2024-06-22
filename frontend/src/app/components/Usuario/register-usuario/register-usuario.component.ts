import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UsuariosService } from 'src/app/services/usuarios/Usuarios.service';
import { RegistroUsuario } from 'src/app/models/RegistroUsuario';

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
      email: new FormControl(null, [Validators.required, Validators.minLength(10), Validators.maxLength(50)]),
      senha: new FormControl(null, [Validators.required, Validators.minLength(1), Validators.maxLength(30)]),
    })
  }

  get propriedade() {
    return this.formulario.controls;
  }

  SelecionarFoto(fileInput: any) : void {
    this.foto = fileInput.target.files[0] as File;
    const reader = new FileReader();
    reader.onload = function(e : any) {
      document.getElementById('foto').removeAttribute('hidden');
      document.getElementById('foto').setAttribute('src', e.target.result);
    }

    reader.readAsDataURL(this.foto);
  }

  EnviarFormulario() : void {
    const usuario = this.formulario.value;
    const formData: FormData = new FormData();
    this.erros = [];

    if (this.foto != null) {
      formData.append('file', this.foto, this.foto.name);
    }

    this.usuarioService.salvarFoto(formData).subscribe(result => {
      const registroUsuario: RegistroUsuario = new RegistroUsuario();
      registroUsuario.nomeUsuario = usuario.nomeUsuario;
      registroUsuario.cpf = usuario.cpf;
      registroUsuario.foto = result.foto;
      registroUsuario.profissao = usuario.profissao;
      registroUsuario.email = usuario.email;
      registroUsuario.senha = usuario.senha;

      this.usuarioService.registrarUsuario(registroUsuario).subscribe(dados => {
        const emailUsuarioLogado = dados.email;

        localStorage.setItem('EmailUsuarioLogado', emailUsuarioLogado)

        this.snackBar.open(dados.mensagem, null, {
          duration: 2000,
          horizontalPosition: 'right',
          verticalPosition: 'top'
        })
        this.router.navigate(['Categorias/listar']);
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
    })
  }

}
