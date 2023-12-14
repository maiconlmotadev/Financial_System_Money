import { MenuService } from '../../services/menu.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent {

  constructor(public menuService: MenuService){

  }

  ngOnInit(){
    this.menuService.selectMenu = 3;
  }
}
