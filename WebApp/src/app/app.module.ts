import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { RoundRollInputsComponent } from './components/round-roll-inputs/round-roll-inputs.component';
import { MatInputModule, MatButtonModule, MatCardModule } from '@angular/material';
import { ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ScoreBoardComponent } from './components/score-board/score-board.component';
import { RoundHeaderComponent } from './components/round-header/round-header.component';
import { TotalScoreHeaderComponent } from './components/total-score-header/total-score-header.component';
import { RoundScoreCellComponent } from './components/round-score-cell/round-score-cell.component';
import { TotalScoreCellComponent } from './components/total-score-cell/total-score-cell.component';
import { HttpClientModule } from '@angular/common/http';
import { environment } from '../environments/environment';
import { MarkRollsPipe } from './pipes/mark-rolls.pipe';
import { HideRoundScorePipe } from './pipes/hide-round-score.pipe';

@NgModule({
  declarations: [
    AppComponent,
    RoundRollInputsComponent,
    ScoreBoardComponent,
    RoundHeaderComponent,
    TotalScoreHeaderComponent,
    RoundScoreCellComponent,
    TotalScoreCellComponent,
    MarkRollsPipe,
    HideRoundScorePipe
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    HttpClientModule
  ],
  providers: [{ provide: "BASE_API_URL", useValue: environment.apiUrl }],
  bootstrap: [AppComponent]
})
export class AppModule { }
