import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Cartao } from 'src/app/models/Cartao';
import { Categoria } from 'src/app/models/Categoria';
import { Despesa } from 'src/app/models/Despesa';
import { Mes } from 'src/app/models/Mes';
import { CartoesService } from 'src/app/services/cartoes/cartoes.service';
import { CategoriasService } from 'src/app/services/categorias/categorias.service';
import { DespesasService } from 'src/app/services/despesas/despesas.service';
import { MesesService } from 'src/app/services/meses/mes.service';

@Component({
  selector: 'app-editar-despesa',
  templateUrl: './editar-despesa.component.html',
  styleUrls: ['./editar-despesa.component.scss']
})
export class EditarDespesaComponent implements OnInit {

  despesa: Observable<Despesa>;
  valorDespesa: number;
  despesaId: number
  cartoes: Cartao[];
  categorias: Categoria[];
  meses: Mes[];
  formulario: any;
  erros: string[];
  usuarioId: string = localStorage.getItem('UsuarioId');

  constructor(private router: Router,
    private route: ActivatedRoute,
    private despesaService: DespesasService,
    private categoriaService: CategoriasService,
    private cartaoService: CartoesService,
    private mesService: MesesService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.erros = [];
    this.despesaId = this.route.snapshot.params.id;

    this.cartaoService.getByUserId(this.usuarioId).subscribe(result => {
      this.cartoes = result;
    })

    this.categoriaService.filtrarCategoriasDespepesas().subscribe(result => {
      this.categorias = result;
    })

    this.mesService.getAll().subscribe(result => {
      this.meses = result;
    })

    this.despesaService.getById(this.despesaId).subscribe(result => {
      this.valorDespesa = result.valor;
      this.formulario = new FormGroup({
        id: new FormControl(result.id),
        cartaoId: new FormControl(null, [Validators.required]),
        descricao: new FormControl(null, [Validators.required, Validators.minLength(1), Validators.maxLength(50)]),
        categoriaId: new FormControl(null, [Validators.required]),
        valor: new FormControl(null, [Validators.required]),
        dia: new FormControl(null, [Validators.required]),
        mesId: new FormControl(null, [Validators.required]),
        ano: new FormControl(null, [Validators.required]),
      })
    });
  }

  get propriedade() {
    return this.formulario.controls;
  }

  VoltarListagem(): void {
    this.router.navigate(['despesas/listar'])
  }

  AtualizarDespesa() : void {
    const categoria = this.formulario.value;
    this.erros = [];
    this.despesaService.update(this.despesaId, categoria).subscribe(result => {
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
