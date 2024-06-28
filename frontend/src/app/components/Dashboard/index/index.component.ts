import { Component, OnInit } from '@angular/core';
import { DashboardService } from 'src/app/services/dashboard/dashboard.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  qtdCartoes: number;
  ganhoTotal: number;
  despesaTotal: number;
  saldo: number;
  usuarioId: string = localStorage.getItem('UsuarioId');

  constructor(private dashboardService: DashboardService) { }

  ngOnInit() {
    this.dashboardService.getCards(this.usuarioId).subscribe(result => {
      this.qtdCartoes = result.qtdCartoes;
      this.ganhoTotal = result.ganhoTotal;
      this.despesaTotal = result.despesaTotal;
      this.saldo = result.saldo;
    });
  }

}
