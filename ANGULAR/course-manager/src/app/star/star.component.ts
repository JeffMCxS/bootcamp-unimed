import { Component, Input, OnChanges } from "@angular/core";

@Component({
    selector: 'app-star',
    templateUrl: './star.component.html', //Informar qual o arquivo de template (html)
    styleUrls: ['./star.component.css'] //Informar qual o arquivo de estilo (css)
})
export class StarComponent implements OnChanges { //Import Add

    @Input() //Variável receber valor de um componente externo, Import Add
    rating: number = 0;

    starWidth: number;

    ngOnChanges(): void {
        this.starWidth = this.rating * 74 / 5; //ou 94 / 5
    }

}
