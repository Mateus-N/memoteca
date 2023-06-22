import { Pensamento } from 'src/app/components/pensamentos/models/pensamento';
import { Component } from '@angular/core';
import { PensamentoService } from '../pensamento.service';
import { PagedPensamentos } from '../models/pagedPensamentos';

@Component({
  selector: 'app-listar-pensamento',
  templateUrl: './listar-pensamento.component.html',
  styleUrls: ['./listar-pensamento.component.css']
})
export class ListarPensamentoComponent {
  listaPensamentos: Pensamento[] = []
  paginaAtual: number = 1;
  haMaisPensamentos!: boolean;
  filtro: string = '';

  constructor(
    private readonly service: PensamentoService
  ) {}

  ngOnInit() {
    this.service.listar(this.paginaAtual, this.filtro).subscribe(pagedPensamentos => {
      this.listaPensamentos = pagedPensamentos.data
      this.ehUltimaPagina(pagedPensamentos)
    });
  }

  carregarMaisPensamentos() {
    if (this.haMaisPensamentos) {
      this.service.listar(++this.paginaAtual, this.filtro).subscribe(pagedPensamentos => {
        this.listaPensamentos.push(...pagedPensamentos.data)
        this.ehUltimaPagina(pagedPensamentos)
      })
    }
  }

  pesquisarPensamentos() {
    this.paginaAtual = 1;
    this.service.listar(this.paginaAtual, this.filtro).subscribe(pagedPensamentos => {
      this.listaPensamentos = pagedPensamentos.data
      this.ehUltimaPagina(pagedPensamentos)
    })
  }

  ehUltimaPagina(pagedPensamentos: PagedPensamentos) : void {
    if (pagedPensamentos.pageNumber == pagedPensamentos.totalPages) {
      this.haMaisPensamentos = false;
    } else {
      this.haMaisPensamentos = true;
    }
  }
}
