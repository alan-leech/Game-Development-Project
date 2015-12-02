/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package entity;

import java.io.Serializable;
import java.util.Collection;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author XRC_7331
 */
@Entity
@Table(name = "user_game")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "UserGame.findAll", query = "SELECT u FROM UserGame u"),
    @NamedQuery(name = "UserGame.findById", query = "SELECT u FROM UserGame u WHERE u.id = :id"),
    @NamedQuery(name = "UserGame.findByLastCompletedLevel", query = "SELECT u FROM UserGame u WHERE u.lastCompletedLevel = :lastCompletedLevel")})
public class UserGame implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "id")
    private Integer id;
    @Basic(optional = false)
    @Column(name = "lastCompletedLevel")
    private int lastCompletedLevel;
    @JoinColumn(name = "game", referencedColumnName = "id")
    @ManyToOne(optional = false)
    private Game game;
    @JoinColumn(name = "user", referencedColumnName = "id")
    @ManyToOne(optional = false)
    private User user;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "userGame")
    private Collection<Score> scores;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "userGame")
    private Collection<OverallScore> overallScores;

    public UserGame() {
    }

    public UserGame(Integer id) {
        this.id = id;
    }

    public UserGame(Integer id, int lastCompletedLevel) {
        this.id = id;
        this.lastCompletedLevel = lastCompletedLevel;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public int getLastCompletedLevel() {
        return lastCompletedLevel;
    }

    public void setLastCompletedLevel(int lastCompletedLevel) {
        this.lastCompletedLevel = lastCompletedLevel;
    }

    public Game getGame() {
        return game;
    }

    public void setGame(Game game) {
        this.game = game;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    @XmlTransient
    public Collection<Score> getScores() {
        return scores;
    }

    public void setScores(Collection<Score> scores) {
        this.scores = scores;
    }

    @XmlTransient
    public Collection<OverallScore> getOverallScoreCollection() {
        return overallScores;
    }

    public void setOverallScoreCollection(Collection<OverallScore> overallScoreCollection) {
        this.overallScores = overallScoreCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (id != null ? id.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof UserGame)) {
            return false;
        }
        UserGame other = (UserGame) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "entity.UserGame[ id=" + id + " ]";
    }

}
