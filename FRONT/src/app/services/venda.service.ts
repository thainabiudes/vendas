import { Venda } from "src/app/models/venda";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: "root",
})
export class VendaService {
    private baseUrl = "http://localhost:5000/api/venda";

    constructor(private http: HttpClient) {}

    create(venda: Venda, carrinhoId: string): Observable<Venda> {
        return this.http.post<Venda>(
            `${this.baseUrl}/create/${carrinhoId}`,
            venda
        );
    }

    getByCartId(carrinhoId: string): Observable<Venda[]> {
        return this.http.get<Venda[]>(
            `${this.baseUrl}/getbycartid/${carrinhoId}`
        );
    }
}
