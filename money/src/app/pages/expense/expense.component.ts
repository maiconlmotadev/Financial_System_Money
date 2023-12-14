import { MenuService } from '../../services/menu.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-expense',
  templateUrl: './expense.component.html',
  styleUrls: ['./expense.component.scss']
})
export class ExpenseComponent {

  constructor(public menuService: MenuService){

  }

  ngOnInit(){
    this.menuService.selectMenu = 4;
  }
}
