import { Component, Input } from '@angular/core';
import { Pensamento } from '../models/pensamento';

@Component({
  selector: 'app-pensamento',
  templateUrl: './pensamento.component.html',
  styleUrls: ['./pensamento.component.css']
})
export class PensamentoComponent {

  @Input()
  pensamento: Pensamento = {
    id: '',
    conteudo: '',
    autoria: '',
    modelo: ''
  }

  larguraPensamento(): string {
    if (this.pensamento.conteudo.length >= 256)
      return 'pensamento-g'
    return 'pensamento-p'
  }
}
