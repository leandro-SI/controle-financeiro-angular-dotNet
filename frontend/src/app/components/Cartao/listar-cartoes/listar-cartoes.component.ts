import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { CartoesService } from 'src/app/services/cartoes/cartoes.service';

@Component({
  selector: 'app-listar-cartoes',
  templateUrl: './listar-cartoes.component.html',
  styleUrls: ['./listar-cartoes.component.scss']
})
export class ListarCartoesComponent implements OnInit {

  cartoes = new MatTableDataSource<any>();
  displayColumns: string[]
  autoCompleteInput = new FormControl();
  opcoesCartoes: string[] = [];
  usuarioId: string = localStorage.getItem('UsuarioId');
  nomesCartoes: Observable<string[]>;

  @ViewChild(MatPaginator, {static: true})
  paginator: MatPaginator;

  @ViewChild(MatSort, {static: true})
  sort: MatSort;

  constructor(private cartaoService: CartoesService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {

    this.cartaoService.getByUserId(this.usuarioId).subscribe(result => {
      result.forEach((c) => {
        this.opcoesCartoes.push(c.nome);
      });

      this.cartoes.data = result;
      this.cartoes.paginator = this.paginator;
      this.cartoes.sort = this.sort;
    });

    this.displayColumns = this.ExibirColunas();

    this.nomesCartoes = this.autoCompleteInput.valueChanges.pipe(startWith(''), map(nome => this.FiltrarNomes(nome)))
  }

  ExibirColunas() : string[] {
    return ['nome', 'bandeira', 'numero', 'limite', 'acoes']
  }

  FiltrarNomes(nome: string) : string[] {
    if (nome.trim().length >= 4) {
      this.cartaoService.filtrar(nome).subscribe(result => {
        this.cartoes.data = result;
      })
    } else {
      if (nome === '') {
        this.cartaoService.getByUserId(this.usuarioId).subscribe(result => {
          this.cartoes.data = result
        })
      }
    }

    return this.opcoesCartoes.filter(cartao =>
      cartao.toLowerCase().includes(nome.toLowerCase())
    )
  }

}
