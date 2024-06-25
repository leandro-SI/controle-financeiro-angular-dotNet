import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CartoesService } from 'src/app/services/cartoes/cartoes.service';

@Component({
  selector: 'app-dialog-delete-cartao',
  templateUrl: './dialog-delete-cartao.component.html',
  styleUrls: ['./dialog-delete-cartao.component.scss']
})
export class DialogDeleteCartaoComponent implements OnInit {

  constructor(@Inject (MAT_DIALOG_DATA) public data: any,
  private cartaoService: CartoesService,
  private snackBar: MatSnackBar) { }

  ngOnInit() {
  }

  ExcluirCartao(id): void {
    this.cartaoService.delete(id).subscribe(result => {
      this.snackBar.open(result.mensagem, null, {
        duration: 3000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
      })
    })
  }

}
