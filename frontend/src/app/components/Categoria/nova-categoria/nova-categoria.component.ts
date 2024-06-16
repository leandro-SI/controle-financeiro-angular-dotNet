import { Component, OnInit } from '@angular/core';
import { Tipo } from 'src/app/models/Tipo';
import { TiposService } from 'src/app/services/tipos/tipos.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-nova-categoria',
  templateUrl: './nova-categoria.component.html',
  styleUrls: ['./nova-categoria.component.scss']
})
export class NovaCategoriaComponent implements OnInit {

  formulario: any;
  tipos: Tipo[]

  constructor(private tipoService: TiposService) { }

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

}
