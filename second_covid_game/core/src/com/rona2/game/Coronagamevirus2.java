//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by Fernflower decompiler)
//

package com.rona2.game;

import com.rona2.game.Screens.PlayScreen;
import com.badlogic.gdx.Game;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;

public class Coronagamevirus2 extends Game {
	public static final int V_WIDTH = 400;
	public static final int V_HEIGHT = 208;
	public SpriteBatch batch;

	public Coronagamevirus2() {
	}

	public void create() {
		this.batch = new SpriteBatch();
		this.setScreen(new PlayScreen(this));
	}

	public void render() {
		super.render();
	}

	public void dispose() {
		this.batch.dispose();
	}
}
