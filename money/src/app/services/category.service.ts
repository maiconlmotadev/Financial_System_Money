import { Category } from './../models/Category';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environment";


@Injectable({
    providedIn: 'root'
})

export class CategoryService {
    constructor( private httpClient : HttpClient) {

    }

    private readonly baseURL = environment["endPoint"];

    AddCategory(category: Category){
        return this.httpClient.post<Category>(`${this.baseURL}/AddCategory`, category)
    }

    ListUserCategories(emailUser: string){
        return this.httpClient.get(`${this.baseURL}/ListUserCategories?emailUser=${emailUser}`);
    }

}