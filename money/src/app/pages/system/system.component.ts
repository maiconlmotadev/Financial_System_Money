import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MenuService } from '../../services/menu.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-system',
  templateUrl: './system.component.html',
  styleUrls: ['./system.component.scss']
})
export class SystemComponent {

  constructor(public menuService: MenuService, private formBuilder: FormBuilder){
  }

  systemForm: FormGroup;

  ngOnInit(){
    this.menuService.selectMenu = 2;

    this.systemForm = this.formBuilder.group(
      {
        name: ['', [Validators.required]]
      }
    )
  }

  formData(){
    return this.systemForm.controls;
  }

  send(){
    debugger
    var data = this.formData();

    alert(data["name"].value);
  }

}
