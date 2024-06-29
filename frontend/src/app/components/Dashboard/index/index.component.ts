import { Component, OnInit } from '@angular/core';
import { DashboardService } from 'src/app/services/dashboard/dashboard.service';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';

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
  anoAtual: number = new Date().getFullYear();
  anoInicial: number = this.anoAtual - 10;
  anos: number[];
  usuarioId: string = localStorage.getItem('UsuarioId');

  dados: ChartDataSets[];
  labels: Label[];
  opcoes = {
    responsive: true,
    legend: {
      labels: {
        usePointStyle: true
      }
    }
  };
  plugins = [];
  tipo = 'line';

  constructor(private dashboardService: DashboardService) { }

  ngOnInit() {
    this.dashboardService.getCards(this.usuarioId).subscribe(result => {
      console.log('Result Cards: ', result)
      this.qtdCartoes = result.qtdCartoes;
      this.ganhoTotal = result.ganhoTotal;
      this.despesaTotal = result.despesaTotal;
      this.saldo = result.saldo;
    });

    this.anos = this.CarregarAnos(this.anoInicial, this.anoAtual);
    console.log('Passou 1')
    this.dashboardService.getDadosAnuaisByUserId(this.usuarioId, this.anoAtual).subscribe(result => {
      console.log('Passou')
      console.log('Result Meses: ', result.meses)
      console.log('Result Ganhos: ', result.ganhos)
      console.log('Result Desnepsas: ', result.despesas)
      this.labels = this.RetornarMeses(result.meses);

      this.dados = [
        {
          data: this.RetornarValoresGanhos(result.meses, result.ganhos),
          label: 'Ganho de R$',
          fill: true,
          borderColor: '#27ae60',
          backgroundColor: '#27ae60',
          pointBackgroundColor: '#27ae60',
          pointBorderColor: '#27ae60',
          pointHoverBackgroundColor: '#27ae60',
          pointHoverBorderColor: '#27ae60',
        },
        {
          data: this.RetornarValoresDespesas(result.meses, result.despesas),
          label: 'Despesa de R$',
          fill: true,
          borderColor: '#c0392b',
          backgroundColor: '#c0392b',
          pointBackgroundColor: '#c0392b',
          pointBorderColor: '#c0392b',
          pointHoverBackgroundColor: '#c0392b',
          pointHoverBorderColor: '#c0392b',
        }
      ];
    });
  }

  CarregarAnos(anoInicial, anoAtual) : number[] {
    const anos = [];

    while(anoInicial <= anoAtual) {
      anos.push(anoInicial);
      anoInicial = anoInicial + 1;
    }

    return anos;
  }

  RetornarMeses(dadosMeses: any) : string[] {
    console.log('dadosMeses: ', dadosMeses)
    const meses = [];
    let indice = 0;
    const qtdMeses = dadosMeses.length;

    while(indice < qtdMeses) {
      meses.push(dadosMeses[indice].nome);
      indice = indice + 1;
    }

    return meses;
  }

  RetornarValoresGanhos(dadosMeses: any, dadosGanhos: any) : number[] {
    const valores = []
    let indiceMeses = 0;
    let indiceGanhos = 0;
    const qtdMeses = dadosMeses.length;
    const qtdGanhos = dadosGanhos.length;

    while(indiceMeses <= qtdMeses - 1) {
      if (indiceGanhos <= qtdGanhos - 1) {
        if (dadosGanhos[indiceGanhos].mesId == dadosMeses[indiceMeses].mesId) {
          valores.push(dadosGanhos[indiceGanhos].valores);
          indiceGanhos = indiceGanhos + 1;
          indiceMeses = indiceMeses + 1;
        } else {
          valores.push(0)
          indiceMeses = indiceMeses + 1;
        }
      } else {
        valores.push(0)
        indiceMeses = indiceMeses + 1;
      }

      return valores;
    }
  }

  RetornarValoresDespesas(dadosMeses: any, dadosDespesas: any) : number[] {
    const valores = []
    let indiceMeses = 0;
    let indiceDespesas = 0;
    const qtdMeses = dadosMeses.length;
    const qtdDespesas = dadosDespesas.length;

    while(indiceMeses <= qtdMeses - 1) {
      if (indiceDespesas <= qtdDespesas - 1) {
        if (dadosDespesas[indiceDespesas].mesId == dadosMeses[indiceMeses].mesId) {
          valores.push(dadosDespesas[indiceDespesas].valores);
          indiceDespesas = indiceDespesas + 1;
          indiceMeses = indiceMeses + 1;
        } else {
          valores.push(0)
          indiceMeses = indiceMeses + 1;
        }
      } else {
        valores.push(0)
        indiceMeses = indiceMeses + 1;
      }

      return valores;
    }
  }

  CarregarDados(anoSelecionado: number) : void {
    this.dashboardService.getDadosAnuaisByUserId(this.usuarioId, anoSelecionado).subscribe(result => {
      this.labels = this.RetornarMeses(result.meses);

      this.dados = [
        {
          data: this.RetornarValoresGanhos(result.meses, result.ganhos),
          label: 'Ganho de R$',
          fill: true,
          borderColor: '#27ae60',
          backgroundColor: '#27ae60',
          pointBackgroundColor: '#27ae60',
          pointBorderColor: '#27ae60',
          pointHoverBackgroundColor: '#27ae60',
          pointHoverBorderColor: '#27ae60',
        },
        {
          data: this.RetornarValoresDespesas(result.meses, result.despesas),
          label: 'Despesa de R$',
          fill: true,
          borderColor: '#c0392b',
          backgroundColor: '#c0392b',
          pointBackgroundColor: '#c0392b',
          pointBorderColor: '#c0392b',
          pointHoverBackgroundColor: '#c0392b',
          pointHoverBorderColor: '#c0392b',
        }
      ];
    });
  }

}
