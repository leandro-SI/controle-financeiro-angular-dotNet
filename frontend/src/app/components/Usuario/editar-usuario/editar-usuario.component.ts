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
    this.usuarioService.getFotoUsuario(this.usuarioId).subscribe(result => {
      this.fotoAnterior = result.imagem;
      this.urlFoto = this.sanitizer.bypassSecurityTrustResourceUrl('data:image/png;base64' + result.imagem);
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

  Voltar(): void {
    this.router.navigate(['cartoes/listar'])
  }


}
