import { Component, OnInit } from '@angular/core';
import { Tipo } from 'src/app/models/Tipo';
import { TiposService } from 'src/app/services/tipos/tipos.service';
import { FormGroup, FormControl } from '@angular/forms';
import { CategoriasService } from './../../../services/categorias/categorias.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nova-categoria',
  templateUrl: './nova-categoria.component.html',
  styleUrls: ['./nova-categoria.component.scss']
})
export class NovaCategoriaComponent implements OnInit {

  formulario: any;
  tipos: Tipo[]

  constructor(private tipoService: TiposService,
    private categoriaService: CategoriasService,
    private router: Router
  ) { }

  ngOnInit() {

    this.tipoService.GetAll().subscribe(result => {
      this.tipos = result;
    })

    this.formulario = new FormGroup({
      nome: new FormControl(null),
      icone: new FormControl(null),
      tipoId: new FormControl(null),
    })
  }

  get propriedade() {
    return this.formulario.controls;
  }

  EnviarFormulario() : void {
    const categoria = this.formulario.value

    this.categoriaService.create(categoria).subscribe(result => {
      this.router.navigate(['categorias/listar']);
    })
  }

  VoltarListagem(): void {
    this.router.navigate(['categorias/listar'])
  }

}
