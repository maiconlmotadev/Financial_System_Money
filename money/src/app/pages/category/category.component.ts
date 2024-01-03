import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MenuService } from '../../services/menu.service';
import { Component } from '@angular/core';
import { SelectModel } from 'src/app/models/SelectModel';
import { SystemService } from 'src/app/services/system.service';
import { FinancialSystem } from 'src/app/models/FinancialSystem';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent {

  constructor(public menuService: MenuService, public formBuilder: FormBuilder, public systemService: SystemService,
    public authService: AuthService){
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

    this.ListUserFinancialSystems();
  }

  formData(){
    return this.categoryForm.controls;
  }

  send(){
    debugger
    var data = this.formData();

    alert(data["name"].value);
  }

  ListUserFinancialSystems(){
    this.systemService.ListUserFinancialSystems(this.authService.getEmailUser())
      .subscribe((response: Array<FinancialSystem>) => {

        var listFinancialSystem = [];

        response.forEach(x => {
          var item = new SelectModel();
          item.id = x.Id.toString();
          item.name = x.Name;

          listFinancialSystem.push(item);
        });

        this.systemsList = listFinancialSystem;
      }
      )

  }

}
