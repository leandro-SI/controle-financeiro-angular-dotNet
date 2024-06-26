import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Cartao } from 'src/app/models/Cartao';
import { Categoria } from 'src/app/models/Categoria';
import { Mes } from 'src/app/models/Mes';
import { CartoesService } from 'src/app/services/cartoes/cartoes.service';
import { CategoriasService } from 'src/app/services/categorias/categorias.service';
import { DespesasService } from 'src/app/services/despesas/despesas.service';
import { MesesService } from 'src/app/services/meses/mes.service';

@Component({
  selector: 'app-nova-despesa',
  templateUrl: './nova-despesa.component.html',
  styleUrls: ['./nova-despesa.component.scss']
})
export class NovaDespesaComponent implements OnInit {

  formulario: any;
  cartoes: Cartao[];
  categorias: Categoria[];
  meses: Mes[];
  erros: string[];
  usuarioId: string = localStorage.getItem('UsuarioId')

  constructor(private despesaService: DespesasService,
    private mesService: MesesService,
    private cartaoService: CartoesService,
    private categoriaService: CategoriasService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.cartaoService.getByUserId(this.usuarioId).subscribe(result => {
      this.cartoes = result
    })

    this.categoriaService.filtrarCategoriasDespepesas().subscribe(result => {
      this.categorias = result;
    })

    this.mesService.getAll().subscribe(result => {
      this.meses = result;
    })

    this.formulario = new FormGroup({
      cartaoId: new FormControl(null, [Validators.required]),
      descricao: new FormControl(null, [Validators.required, Validators.minLength(1), Validators.maxLength(50)]),
      categoriaId: new FormControl(null, [Validators.required]),
      valor: new FormControl(null, [Validators.required]),
      mesId: new FormControl(null, [Validators.required]),
      ano: new FormControl(null, [Validators.required]),
      usuarioId: new FormControl(this.usuarioId)
    })
  }

  get propriedade() {
    return this.formulario.controls;
  }

  VoltarListagem(): void {
    this.router.navigate(['despesas/listar'])
  }

}
