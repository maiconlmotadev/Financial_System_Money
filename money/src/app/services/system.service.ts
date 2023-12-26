import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environment";
import { FinancialSystem } from "../models/FinancialSystem";

@Injectable({
    providedIn: 'root'
})

export class SystemService {
    constructor( private httpClient : HttpClient) {

    }

    private readonly baseURL = environment["endPoint"];

    AddFinancialSystem(financialSystem: FinancialSystem){
        return this.httpClient.post<FinancialSystem>(`${this.baseURL}/AddFinancialSystem`, financialSystem)
    }

    ListUserFinancialSystems(emailUser: string){
        return this.httpClient.get(`${this.baseURL}/ListUserFinancialSystems?emailUser=${emailUser}`);
    }

    RegisterUserInTheSystem(systemId: number, userEmail: string){
        return this.httpClient.post<any>(`${this.baseURL}/RegisterUserInTheSystem?systemId=${systemId}&userEmail=${userEmail}`, null)
    }
}