import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { NavbarModule } from "src/app/components/navbar/navbar.module";
import { SidebarModule } from "src/app/components/sidebar/sidebar.module";
import { CategoryComponent } from "./category.component";
import { CategoryRoutingModule } from "./category-routing.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgSelectModule } from "@ng-select/ng-select";

@NgModule(
    {
        providers:[],
        declarations:[CategoryComponent],
        imports:[
            CommonModule,
            CategoryRoutingModule,
            NavbarModule,
            SidebarModule,
            
            FormsModule,
            ReactiveFormsModule,
            NgSelectModule
        ]
    }
)

export class CategoryModule{}