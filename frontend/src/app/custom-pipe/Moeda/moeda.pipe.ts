import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'currencyFormat'
})
export class MoedaPipe implements PipeTransform {

  transform(value: number, currency: string = 'R$'): string {
    if (value === null || value === undefined) {
      return '';
    }

    const isNegative = value < 0;
    const absValue = Math.abs(value).toFixed(2).replace('.', ',');
    return `${currency} ${isNegative ? '-' : ''}${absValue}`;
  }

  // transform(value: number): string {
  //   return value.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
  // }

}
