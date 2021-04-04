//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by Fernflower decompiler)
//

package com.rona2.game.Screens;

import com.rona2.game.Scenes.Hud;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Screen;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.utils.viewport.FitViewport;
import com.badlogic.gdx.utils.viewport.Viewport;
import com.rona2.game.Coronagamevirus2;

public class PlayScreen implements Screen {
    private com.rona2.game.Coronagamevirus2 game;
    private OrthographicCamera gamecam;
    private Viewport gamePort;
    private Hud hud;

    public PlayScreen(com.rona2.game.Coronagamevirus2 game) {
        this.game = game;
        this.gamecam = new OrthographicCamera();
        this.gamePort = new FitViewport(400.0F, 208.0F, this.gamecam);
        this.hud = new Hud(game.batch);
    }

    public void show() {
    }

    public void render(float delta) {
        Gdx.gl.glClearColor(1.0F, 0.0F, 0.0F, 1.0F);
        Gdx.gl.glClear(16384);
        this.game.batch.setProjectionMatrix(this.hud.stage.getCamera().combined);
        this.hud.stage.draw();
    }

    public void resize(int width, int height) {
        this.gamePort.update(width, height);
    }

    public void pause() {
    }

    public void resume() {
    }

    public void hide() {
    }

    public void dispose() {
    }
}
