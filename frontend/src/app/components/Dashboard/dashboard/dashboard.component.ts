import { Component, OnInit } from '@angular/core';
import { AuthGuardService } from 'src/app/services/auth/auth-guard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  isAdministrador: boolean;

  constructor(private authGuard: AuthGuardService) { }

  ngOnInit() {
    this.isAdministrador = this.authGuard.VerificarAdministrador();
  }

}
