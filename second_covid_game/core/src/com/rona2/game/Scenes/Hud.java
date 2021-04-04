//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by Fernflower decompiler)
//

package com.rona2.game.Scenes;

import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.scenes.scene2d.Stage;
import com.badlogic.gdx.scenes.scene2d.ui.Label;
import com.badlogic.gdx.scenes.scene2d.ui.Table;
import com.badlogic.gdx.scenes.scene2d.ui.Label.LabelStyle;
import com.badlogic.gdx.utils.viewport.FitViewport;
import com.badlogic.gdx.utils.viewport.Viewport;

public class Hud {
    public Stage stage;
    private Viewport viewport;

    private Integer worldTimer;
    private float timeCount;
    private Integer score;

    Label countdownLabel;
    Label scoreLabel;
    Label timeLabel;
    Label levelLabel;
    Label worldLabel;
    Label covidLabel;

    public Hud(SpriteBatch sb) {
        worldTimer = 300;
        timeCount = 0;
        score = 0;

        viewport = new FitViewport(400.0F, 208.0F,
                new OrthographicCamera());
        this.stage = new Stage(this.viewport, sb);

        Table table = new Table();
        table.top();
        table.setFillParent(true);
        this.countdownLabel = new Label(String.format("%03d", this.worldTimer),
                new Label.LabelStyle(new BitmapFont(), Color.WHITE));
        this.scoreLabel = new Label(String.format("%06d", this.score),
                new Label.LabelStyle(new BitmapFont(), Color.WHITE));
        this.timeLabel = new Label("TIME",
                new Label.LabelStyle(new BitmapFont(), Color.WHITE));
        this.levelLabel = new Label("1-1",
                new Label.LabelStyle(new BitmapFont(), Color.WHITE));
        this.worldLabel = new Label("WORLD",
                new Label.LabelStyle(new BitmapFont(), Color.WHITE));
        this.covidLabel = new Label("CORONA",
                new Label.LabelStyle(new BitmapFont(), Color.WHITE));

        table.add(this.covidLabel).expandX().padTop(10.0F);
        table.add(this.worldLabel).expandX().padTop(10.0F);
        table.add(this.timeLabel).expandX().padTop(10.0F);
        table.row();
        table.add(this.scoreLabel).expandX();
        table.add(this.levelLabel).expandX();
        table.add(this.countdownLabel).expandX();
        this.stage.addActor(table);
    }
}
