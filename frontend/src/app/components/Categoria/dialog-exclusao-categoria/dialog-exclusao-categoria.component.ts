import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CategoriasService } from 'src/app/services/categorias/categorias.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-dialog-exclusao-categoria',
  templateUrl: './dialog-exclusao-categoria.component.html',
  styleUrls: ['./dialog-exclusao-categoria.component.scss']
})
export class DialogExclusaoCategoriaComponent implements OnInit {

  constructor(@Inject (MAT_DIALOG_DATA) public data: any,
  private categoriasService: CategoriasService,
  private snackBar: MatSnackBar) { }

  ngOnInit() {

  }

  ExcluirCategoria(id): void {
    this.categoriasService.delete(id).subscribe(result => {
      this.snackBar.open(result.mensagem, null, {
        duration: 2000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
      })
    })
  }

}
