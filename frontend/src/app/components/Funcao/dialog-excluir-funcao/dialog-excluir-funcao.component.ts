import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FuncoesService } from 'src/app/services/funcoes/funcoes.service';

@Component({
  selector: 'app-dialog-excluir-funcao',
  templateUrl: './dialog-excluir-funcao.component.html',
  styleUrls: ['./dialog-excluir-funcao.component.scss']
})
export class DialogExcluirFuncaoComponent implements OnInit {

  constructor(@Inject (MAT_DIALOG_DATA) public data: any,
  private funcaoService: FuncoesService,
  private snackBar: MatSnackBar) { }

  ngOnInit() {
  }

  ExcluirFuncao(id): void {
    this.funcaoService.delete(id).subscribe(result => {
      this.snackBar.open(result.mensagem, null, {
        duration: 3000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
      })
    })
  }

}
