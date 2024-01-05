import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MenuService } from '../../services/menu.service';
import { Component } from '@angular/core';
import { FinancialSystem } from 'src/app/models/FinancialSystem';
import { SystemService } from 'src/app/services/system.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-system',
  templateUrl: './system.component.html',
  styleUrls: ['./system.component.scss']
})
export class SystemComponent {

  constructor(
    public menuService: MenuService, 
    public formBuilder: FormBuilder, 
    public systemService: SystemService,
    public authService: AuthService){ }

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

    let item = new FinancialSystem();
    item.Name = data["name"].value;

    item.Id = 0;
    item.Month = 0;
    item.Year = 0;
    item.ClosingDay = 0;
    item.GenerateExpenseCopy = true;
    item.MonthCopy = 0;
    item.YearCopy=  0;

    this.systemService.AddFinancialSystem(item)
    .subscribe((response: FinancialSystem) => {
      this.systemForm.reset();

      this.systemService.RegisterUserInTheSystem(response.Id,this.authService.getEmailUser())
      .subscribe((response: any) => {
        debugger
      } , (error) => console.error(error), () => {})
      
    } , (error) => console.error(error), () => {})

  }




}
