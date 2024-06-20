import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Funcao } from 'src/app/models/Funcao';
import { FuncoesService } from 'src/app/services/funcoes/funcoes.service';

@Component({
  selector: 'app-editar-funcao',
  templateUrl: './editar-funcao.component.html',
  styleUrls: ['./editar-funcao.component.scss']
})
export class EditarFuncaoComponent implements OnInit {

  categoria: Observable<Funcao>;
  nomeFuncao: string;
  funcaoId: string;
  formulario: any;
  erros: string[];

  constructor(private router: Router,
    private route: ActivatedRoute,
    private funcaoService: FuncoesService,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.erros = [];
    this.funcaoId = this.route.snapshot.params.id;

    this.funcaoService.getById(this.funcaoId).subscribe(result => {
      this.nomeFuncao = result.name;
      this.formulario = new FormGroup({
        id: new FormControl(result.id),
        name: new FormControl(result.name, [Validators.required, Validators.maxLength(50)]),
        descricao: new FormControl(result.descricao, [Validators.required, Validators.maxLength(50)])
      })
    });
  }

  get propriedade() {
    return this.formulario.controls;
  }

  VoltarListagem(): void {
    this.router.navigate(['funcoes/listar'])
  }

  AtualizarFuncao() : void {
    const funcao = this.formulario.value;
    this.erros = [];
    this.funcaoService.update(this.funcaoId, funcao).subscribe(result => {
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
