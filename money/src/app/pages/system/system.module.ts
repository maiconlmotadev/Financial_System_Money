import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SystemComponent } from "./system.component";
import { SystemRoutingModule } from "./system-routing.module";
import { NavbarModule } from "src/app/components/navbar/navbar.module";
import { SidebarModule } from "src/app/components/sidebar/sidebar.module";

@NgModule(
    {
        providers:[],
        declarations:[SystemComponent],
        imports:[
            CommonModule,
            SystemRoutingModule,
            NavbarModule,
            SidebarModule
        ]
    }
)

export class SystemModule{}