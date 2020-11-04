import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map, retry } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { RaioPreco } from "../model/raio-preco.model";
import { PrecoFrete } from "../model/preco-frete.model";

@Injectable({
  providedIn: "root",
})
export class RaioPrecoService {
  private endPoint: string;

  constructor(private http: HttpClient) {
    this.endPoint = `${environment.Api}raioPreco/`;
  }

  httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
  };

  insertMany(arr: RaioPreco[]): Observable<any> {
    return this.http.post(`${this.endPoint}`, arr).pipe(
      retry(2),
      map((resp) => resp)
    );
  }

  verificarFrete(address_text: string): Observable<PrecoFrete[]> {
    return this.http
      .get(`${this.endPoint}verificar_frete/${address_text}`)
      .pipe(
        retry(2),
        map((resp: any) => {
          if (resp.data.result)
            return resp.data.result.map((x) => PrecoFrete.Create(x));
          else return [];
        })
      );
  }
}
