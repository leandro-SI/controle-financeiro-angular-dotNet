import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UpdateUsuario } from 'src/app/models/UpdateUsuario';
import { UsuariosService } from 'src/app/services/usuarios/Usuarios.service';

@Component({
  selector: 'app-editar-usuario',
  templateUrl: './editar-usuario.component.html',
  styleUrls: ['./editar-usuario.component.css']
})
export class EditarUsuarioComponent implements OnInit {

  usuario: Observable<UpdateUsuario>;
  formulario: any;
  erros: string[];
  usuarioId: string = localStorage.getItem('UsuarioId');
  emailUsuario: string;
  urlFoto: SafeResourceUrl;
  foto: File = null;
  fotoAnterior: File = null;

  constructor(private router: Router,
    private usuarioService: UsuariosService,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private sanitizer: DomSanitizer
  ) { }

  ngOnInit() {
    this.erros = [];

    this.usuarioService.getFotoUsuario(this.usuarioId).subscribe(result => {
      this.fotoAnterior = result.imagem;
      this.urlFoto = this.sanitizer.bypassSecurityTrustResourceUrl('data:image/png;base64,' + result.imagem);
    });

    this.usuarioService.getById(this.usuarioId).subscribe(result => {
      this.emailUsuario = result.email;

      this.formulario = new FormGroup({
        id: new FormControl(result.id),
        userName: new FormControl(result.userName, [Validators.required, Validators.minLength(10), Validators.maxLength(50)]),
        email: new FormControl(result.email, [Validators.required, Validators.minLength(10), Validators.maxLength(50), Validators.email]),
        cpf: new FormControl(result.cpf, [Validators.required, Validators.minLength(1), Validators.maxLength(20)]),
        profissao: new FormControl(result.profissao, [Validators.required, Validators.minLength(1), Validators.maxLength(30)]),
        foto: new FormControl(null),
      })

    })

  }

  get propriedade() {
    return this.formulario.controls;
  }

  SelecionarFoto(fileInput: any) : void {
    this.foto = fileInput.target.files[0] as File;

    const reader = new FileReader();

    reader.onload = function(e: any) {
      document.getElementById('foto').removeAttribute('hidden');
      document.getElementById('foto').setAttribute('src', e.target.result);
    }

    reader.readAsDataURL(this.foto);
  }

  AtualizarUsuario() : void {
    const dados = this.formulario.value;
    this.erros = [];

    if (this.foto != null) {
      const formData: FormData = new FormData();
      formData.append('file', this.foto, this.foto.name);

      this.usuarioService.salvarFoto(formData).subscribe(result => {
        const updateUsuario: UpdateUsuario = new UpdateUsuario()
        updateUsuario.id = dados.id;
        updateUsuario.userName = dados.userName;
        updateUsuario.cpf = dados.cpf;
        updateUsuario.email = dados.email;
        updateUsuario.profissao = dados.profissao;
        updateUsuario.foto = result.foto;

        this.usuarioService.update(updateUsuario).subscribe(response => {
          this.snackBar.open(response.mensagem, null, {
            duration: 3000,
            horizontalPosition: 'right',
            verticalPosition: 'top'
          })
          this.Voltar();
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
    } else {
      const updateUsuario: UpdateUsuario = new UpdateUsuario()
      updateUsuario.id = dados.id;
      updateUsuario.userName = dados.userName;
      updateUsuario.cpf = dados.cpf;
      updateUsuario.email = dados.email;
      updateUsuario.profissao = dados.profissao;
      updateUsuario.foto = this.fotoAnterior;

      this.usuarioService.update(updateUsuario).subscribe(response => {
        this.snackBar.open(response.mensagem, null, {
          duration: 3000,
          horizontalPosition: 'right',
          verticalPosition: 'top'
        })
        this.Voltar();
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

  Voltar(): void {
    this.router.navigate(['cartoes/listar'])
  }


}
