/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package session;

import entity.OverallScore;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

/**
 *
 * @author XRC_7331
 */
@Stateless
public class OverallScoreFacade extends AbstractFacade<OverallScore> {
    @PersistenceContext(unitName = "WEBServerPU")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public OverallScoreFacade() {
        super(OverallScore.class);
    }

}
