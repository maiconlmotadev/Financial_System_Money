import { MenuService } from './../../services/menu.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {

  constructor(public menuService: MenuService){

  }

  ngOnInit(){
    this.menuService.selectMenu = 1;
  }
}
