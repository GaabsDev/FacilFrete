import { EnderecoModel } from "../model/endereco.model";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map, retry } from "rxjs/operators";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class EnderecoService {
  private endPoint: string;

  constructor(private http: HttpClient) {
    this.endPoint = `${environment.Api}cep/`;
  }

  httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
  };

  getEndereco(cep: string): Observable<EnderecoModel> {
    return this.http.get(`${this.endPoint}${cep}`).pipe(
      retry(5),
      map((resp) => new EnderecoModel(resp))
    );
  }
}
