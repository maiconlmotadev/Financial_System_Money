import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MenuService } from '../../services/menu.service';
import { Component } from '@angular/core';
import { SelectModel } from 'src/app/models/SelectModel';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent {

  constructor(public menuService: MenuService, private formBuilder: FormBuilder){
  }

  systemsList = new Array<SelectModel>();
  systemSelect = new SelectModel();

  categoryForm: FormGroup;

  ngOnInit(){
    this.menuService.selectMenu = 3;

    this.categoryForm = this.formBuilder.group(
      {
        name: ['', [Validators.required]]
      }
    )
  }

  formData(){
    return this.categoryForm.controls;
  }

  send(){
    debugger
    var data = this.formData();

    alert(data["name"].value);
  }

}
