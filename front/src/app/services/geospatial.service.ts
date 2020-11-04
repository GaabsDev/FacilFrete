import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map, retry } from "rxjs/operators";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class GeospatialService {
  private endPoint: string;

  constructor(private http: HttpClient) {
    this.endPoint = `${environment.Api}geospatial/`;
  }

  httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
  };

  reverseGeocode(lat: number, log: number): Observable<any> {
    return this.http.get(`${this.endPoint}reverse_geocode/${lat}/${log}`).pipe(
      retry(2),
      map((resp) => resp)
    );
  }

  geocode(text: string): Observable<any> {
    return this.http.get(`${this.endPoint}geocode/${text}`).pipe(
      retry(2),
      map((resp) => resp)
    );
  }
}
