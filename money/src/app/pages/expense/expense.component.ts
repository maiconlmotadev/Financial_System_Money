import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MenuService } from '../../services/menu.service';
import { Component } from '@angular/core';
import { SelectModel } from 'src/app/models/SelectModel';

@Component({
  selector: 'app-expense',
  templateUrl: './expense.component.html',
  styleUrls: ['./expense.component.scss']
})
export class ExpenseComponent {

  constructor(public menuService: MenuService, private formBuilder: FormBuilder){
  }

  systemsList = new Array<SelectModel>();
  systemSelect = new SelectModel();

  categoriesList = new Array<SelectModel>();
  categorySelect = new SelectModel();

  expenseForm: FormGroup;

  ngOnInit(){
    this.menuService.selectMenu = 4;

    this.expenseForm = this.formBuilder.group(
      {
        name: ['', [Validators.required]]
      }
    )
  }

  formData(){
    return this.expenseForm.controls;
  }

  send(){
    debugger
    var data = this.formData();

    alert(data["name"].value);
  }

}
