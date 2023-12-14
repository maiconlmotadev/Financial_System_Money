import { MenuService } from '../../services/menu.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-system',
  templateUrl: './system.component.html',
  styleUrls: ['./system.component.scss']
})
export class SystemComponent {

  constructor(public menuService: MenuService){

  }

  ngOnInit(){
    this.menuService.selectMenu = 2;
  }
}
