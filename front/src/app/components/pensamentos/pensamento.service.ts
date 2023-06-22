import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PagedPensamentos } from './models/pagedPensamentos';
import { CreatePensamentoDto } from './models/CreatePensamentoDto';
import { Pensamento } from './models/pensamento';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PensamentoService {
  private readonly api: string = environment.apiUrl;

  constructor(
    private readonly http: HttpClient,
  ) {}

  public listar(pagina: number, filtro: string): Observable<PagedPensamentos> {
    const itensPorPagina = 6;

    let params = new HttpParams()
      .set("page", pagina)
      .set("pageSize", itensPorPagina)

    if (filtro.trim().length > 2) {
      params = params.set("busca", filtro)
    }

    return this.http
      .get<PagedPensamentos>(this.api, { params });
  }

  public criar(pensamento: CreatePensamentoDto): Observable<Pensamento> {
    return this.http.post<Pensamento>(this.api, pensamento);
  }

  public editar(pensamento: Pensamento): Observable<Pensamento> {
    return this.http.put<Pensamento>(this.api, pensamento);
  }

  public excluir(id: string): Observable<Pensamento> {
    const url = `${this.api}/${id}`;
    return this.http.delete<Pensamento>(url);
  }

  public buscarPorId(id: string): Observable<Pensamento> {
    const url = `${this.api}/${id}`;
    return this.http.get<Pensamento>(url);
  }
}
