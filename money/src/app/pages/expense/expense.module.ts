import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ExpenseComponent } from "./expense.component";
import { ExpenseRoutingModule } from "./expense-routing.module";
import { NavbarModule } from "src/app/components/navbar/navbar.module";
import { SidebarModule } from "src/app/components/sidebar/sidebar.module";

@NgModule(
    {
        providers:[],
        declarations:[ExpenseComponent],
        imports:[
            CommonModule,
            ExpenseRoutingModule,
            NavbarModule,
            SidebarModule
        ]
    }
)

export class ExpenseModule{}