import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Cartao } from 'src/app/models/Cartao';
import { CartoesService } from 'src/app/services/cartoes/cartoes.service';

@Component({
  selector: 'app-editar-cartao',
  templateUrl: './editar-cartao.component.html',
  styleUrls: ['./editar-cartao.component.scss']
})
export class EditarCartaoComponent implements OnInit {

  cartao: Observable<Cartao>;
  nomeCartao: string;
  cartaoId: number
  usuarioId: string = localStorage.getItem('UsuarioId');
  formulario: any;
  erros: string[];

  constructor(private router: Router,
    private route: ActivatedRoute,
    private cartaoService: CartoesService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.erros = [];
    this.cartaoId = this.route.snapshot.params.id;

    this.cartaoService.getById(this.cartaoId).subscribe(result => {
      this.nomeCartao = result.nome;
      this.formulario = new FormGroup({
        id: new FormControl(result.id),
        nome: new FormControl(result.nome, [Validators.required, Validators.min(1), Validators.maxLength(20)]),
        bandeira: new FormControl(result.bandeira, [Validators.required, Validators.min(1), Validators.maxLength(15)]),
        numero: new FormControl(result.numero, [Validators.required, Validators.min(1), Validators.maxLength(20)]),
        limite: new FormControl(result.limite, [Validators.required]),
        usuarioId: new FormControl(result.usuarioId, [Validators.required])
      })
    });
  }

  get propriedade() {
    return this.formulario.controls;
  }

  VoltarListagem(): void {
    this.router.navigate(['cartoes/listar'])
  }

  AtualizarCartao() : void {
    const cartao = this.formulario.value;
    this.erros = [];
    this.cartaoService.update(this.cartaoId, cartao).subscribe(result => {
      this.snackBar.open(result.mensagem, null, {
        duration: 3000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
      })
      this.VoltarListagem();
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
