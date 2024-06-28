import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { GanhosService } from 'src/app/services/ganhos/ganhos.service';

@Component({
  selector: 'app-dialog-delete-ganho',
  templateUrl: './dialog-delete-ganho.component.html',
  styleUrls: ['./dialog-delete-ganho.component.css']
})
export class DialogDeleteGanhoComponent implements OnInit {


  constructor(@Inject (MAT_DIALOG_DATA) public data: any,
  private ganhoService: GanhosService,
  private snackBar: MatSnackBar) { }

  ngOnInit() {
  }

  ExcluirGanho(id): void {
    this.ganhoService.delete(id).subscribe(result => {
      this.snackBar.open(result.mensagem, null, {
        duration: 3000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
      })
    })
  }

}
