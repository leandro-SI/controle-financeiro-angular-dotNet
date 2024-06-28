import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Categoria } from 'src/app/models/Categoria';
import { Ganho } from 'src/app/models/Ganho';
import { Mes } from 'src/app/models/Mes';
import { CategoriasService } from 'src/app/services/categorias/categorias.service';
import { GanhosService } from 'src/app/services/ganhos/ganhos.service';
import { MesesService } from 'src/app/services/meses/mes.service';

@Component({
  selector: 'app-editar-ganho',
  templateUrl: './editar-ganho.component.html',
  styleUrls: ['./editar-ganho.component.css']
})
export class EditarGanhoComponent implements OnInit {

  ganho: Observable<Ganho>;
  valorGanho: number;
  ganhoId: number
  categorias: Categoria[];
  meses: Mes[];
  formulario: any;
  erros: string[];
  usuarioId: string = localStorage.getItem('UsuarioId');

  constructor(private router: Router,
    private route: ActivatedRoute,
    private ganhoService: GanhosService,
    private categoriaService: CategoriasService,
    private mesService: MesesService,
    private snackBar: MatSnackBar
  ) { }


  ngOnInit() {
    this.erros = [];
    this.ganhoId = this.route.snapshot.params.id;

    this.categoriaService.filtrarCategoriasGanhos().subscribe(result => {
      this.categorias = result;
    })

    this.mesService.getAll().subscribe(result => {
      this.meses = result;
    })

    this.ganhoService.getById(this.ganhoId).subscribe(result => {
      this.valorGanho = result.valor;
      this.formulario = new FormGroup({
        id: new FormControl(result.id),
        descricao: new FormControl(result.descricao, [Validators.required, Validators.minLength(1), Validators.maxLength(50)]),
        categoriaId: new FormControl(result.categoriaId, [Validators.required]),
        valor: new FormControl(result.valor, [Validators.required]),
        dia: new FormControl(result.dia, [Validators.required]),
        mesId: new FormControl(result.mesId, [Validators.required]),
        ano: new FormControl(result.ano, [Validators.required]),
        usuarioid: new FormControl(this.usuarioId),
      })
    });
  }

  get propriedade() {
    return this.formulario.controls;
  }

  VoltarListagem(): void {
    this.router.navigate(['ganhos/listar'])
  }

  AtualizarGanho() : void {
    const ganho = this.formulario.value;
    this.erros = [];
    this.ganhoService.update(this.ganhoId, ganho).subscribe(result => {
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
