import { MenuService } from './../../services/menu.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})

export class SidebarComponent {

  constructor( private router : Router, public menuService: MenuService){

  }

  selectMenu(menu: number){

    switch (menu) {
      case 1:
        this.router.navigate(['/dashboard']);
        break;

      case 2:
        this.router.navigate(['/system']);
        break;

      case 3:
        this.router.navigate(['/category']);
        break;
  
      case 4:
        this.router.navigate(['/expense']);
        break;

      default:
        break;
    }
    
    this.menuService.selectMenu = menu;

  }

}
