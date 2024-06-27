import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DespesasService } from 'src/app/services/despesas/despesas.service';

@Component({
  selector: 'app-dialog-delete-despesa',
  templateUrl: './dialog-delete-despesa.component.html',
  styleUrls: ['./dialog-delete-despesa.component.scss']
})
export class DialogDeleteDespesaComponent implements OnInit {

  constructor(@Inject (MAT_DIALOG_DATA) public data: any,
  private despesaService: DespesasService,
  private snackBar: MatSnackBar) { }

  ngOnInit() {
  }

  ExcluirDespesa(id): void {
    this.despesaService.delete(id).subscribe(result => {
      this.snackBar.open(result.mensagem, null, {
        duration: 3000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
      })
    })
  }

}
