
import { Component, Inject } from '@angular/core';

@Component({
    selector: 'Myinput',
    template: `<h1>example with custom item template</h1>
  <section class="col-sm-12 custom">
    <div class="search-results style-3">
      <input type="text" [value]="query2"
        ngxTypeahead
        [taUrl]="url"
        [taParams]="params"
        (taSelected)="handleResult2Selected($event)"
      >
    </div>
    
  </section>`
})
export class InputComponent {
    constructor( @Inject('ORIGIN_URL') originUrl: string) {
        this.url = originUrl + '/api/SampleData/TypeAheadRequest'
    }
    title = 'This is Angular TypeAhead v';

    public url;
    public url2 = 'data.json';
    public params = {
        hl: 'en',
        ds: 'yt',
        xhr: 't',
        client: 'youtube'
    };
    public query = '';
    public query2 = '';

    handleResultSelected(result) {
        this.query = result;
    }

    handleResult2Selected(result) {
        console.log(result);
        this.query2 = result;
    }

}
